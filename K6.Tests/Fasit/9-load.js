import http from 'k6/http';
import { check, group, sleep } from 'k6';

export const options = {
  stages: [
    { duration: '5m', target: 100 }, // simulate ramp-up of traffic from 1 to 100 users over 5 minutes.
    { duration: '10m', target: 100 }, // stay at 100 users for 10 minutes
    { duration: '5m', target: 0 }, // ramp-down to 0 users
  ],
  thresholds: {
    'http_req_duration': ['p(99)<1000'], // 99% of requests must complete below 1s
  },
};

const BASE_URL = 'http://localhost:5199';

export default () => {


  const hikes = http.get(`${BASE_URL}/api/HikeRatings`).json();
  check(hikes, { 'retrieved hikes': (obj) => obj.length > 0 });

  sleep(1);
};
