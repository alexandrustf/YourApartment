import pickle
import numpy as np
from flask import Flask, request
import json
import pandas as pd
from sklearn.ensemble import RandomForestRegressor
from flask_cors import CORS

model = None
app = Flask(__name__)
CORS(app)


def load_model():
    global model
    # model variable refers to the global variable
    with open('random_forest1.pkl', 'rb') as f:
        model = pickle.load(f)


@app.route('/')
def home_endpoint():
    return 'Hello World!'


@app.route('/predict', methods=['POST'])
def get_prediction():
    # Works only for a single sample
    if request.method == 'POST':
        data = request.get_json(force=True)
        data =pd.DataFrame(data)
#         data = np.array(data)[np.newaxis, :]
        prediction = model.predict(data)
        return str(prediction[0])


if __name__ == '__main__':
    load_model()  # load model at the beginning once only
    app.run(host='0.0.0.0', port=8080, debug=True)