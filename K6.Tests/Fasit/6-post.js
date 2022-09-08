import http from 'k6/http';

export default function () {
  const url = 'http://localhost:5199/api/HikeRatings';
  const payload = JSON.stringify({
    "id": 5,
    "hikeName": "Himmelbjerget",
    "rating": 2,
  });

  const params = {
    headers: {
      'Content-Type': 'application/json',
    },
  };

  http.post(url, payload, params);
}