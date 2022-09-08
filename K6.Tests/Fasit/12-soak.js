import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
  stages: [
    { duration: '2m', target: 400 }, // ramp up to 400 users
    { duration: '3h56m', target: 400 }, // stay at 400 for ~4 hours
    { duration: '2m', target: 0 }, // scale down. (optional)
  ],
};

const API_BASE_URL = 'http://localhost:5199';

export default function () {
  http.batch([
    ['GET', `${API_BASE_URL}/api/HikeRatings/1`],
    ['GET', `${API_BASE_URL}/api/HikeRatings/2`],
    ['GET', `${API_BASE_URL}/api/HikeRatings/3`],
    ['GET', `${API_BASE_URL}/api/HikeRatings/4`],
  ]);

  sleep(1);
}
