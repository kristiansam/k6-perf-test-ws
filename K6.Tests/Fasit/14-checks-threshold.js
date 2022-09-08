import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 50,
  duration: '10s',
  thresholds: {
    checks: ['rate>0.9'], // the rate of successful checks should be higher than 90%
  },
};

export default function () {
  const res = http.get('http://localhost:5199/api/HikeRatings');

  check(res, {
    'status is 500': (r) => r.status == 500,
  });

  sleep(1);
}