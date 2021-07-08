@echo off
docker build -t ghcr.io/ac-4/xcexample.api.sometext:latest -t xcexample.api.sometext -t localhost:5000/xcexample.api.sometext .
docker push localhost:5000/xcexample.api.sometext:latest
docker push ghcr.io/ac-4/xcexample.api.sometext:latest