from flask import Flask, request, jsonify
from datetime import datetime
import json
import os

app = Flask(__name__)

LOG_FILE = "telemetry_log.jsonl"  # satır satır JSON log

@app.route("/telemetry", methods=["POST"])
def telemetry():
    data = request.get_json(silent=True)  # bozuk JSON gelirse patlamasın
    if data is None:
        return jsonify({"status": "error", "message": "Invalid JSON"}), 400

    # timestamp yoksa ekle
    data.setdefault("received_at_utc", datetime.utcnow().isoformat() + "Z")

    # 1) Konsola bas
    print("TELEMETRY EVENT:", data)

    # 2) Dosyaya yaz (jsonl)
    with open(LOG_FILE, "a", encoding="utf-8") as f:
        f.write(json.dumps(data, ensure_ascii=False) + "\n")

    return jsonify({"status": "ok"}), 200


@app.route("/health", methods=["GET"])
def health():
    return jsonify({"status": "ok"}), 200


if __name__ == "__main__":
    # 0.0.0.0 -> yerel ağdan da erişilebilir (istersen 127.0.0.1 yap)
    app.run(host="127.0.0.1", port=5000, debug=True)
