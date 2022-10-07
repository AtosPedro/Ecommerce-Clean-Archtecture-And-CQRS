# Stage 1: Build an Angular Docker Image
FROM node as build
WORKDIR /apps
COPY . .
RUN npm install
COPY . /apps
ARG configuration=Ecommerce.WebUI
RUN npm run build --outputPath=./apps/dist/out -configuration $configuration

# Stage 2, use the compiled app, ready for production with Nginx
FROM nginx:alpine
COPY nginx-custom.conf /etc/nginx/conf.d/
RUN rm -rf /usr/share/nginx/html/*
COPY --from=build /apps/dist/out/ /usr/share/nginx/html