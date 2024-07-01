FROM node:alpine AS build
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build

FROM nginx:latest AS host
COPY --from=build /app/dist/music-ui/browser /usr/share/nginx/html
EXPOSE 80