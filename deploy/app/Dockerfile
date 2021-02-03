FROM node:12

RUN mkdir -p /node_modules

RUN apt-get update && apt-get install -yq libgconf-2-4

COPY app/package.json .

COPY app .

RUN npm install

RUN chmod 0777 /entrypoint.sh

ENTRYPOINT ["/entrypoint.sh"]