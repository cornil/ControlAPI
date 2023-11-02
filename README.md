# Tutorial : Take control of your API

This project show a step by step guide to expose data threw an API.

This is more focus on system design than API development.

The goal is to build a system with performance, availability, scalability and observability

The exemple is shown in dotnet but can be applied with any langage

In this project we use french open data for electric vehicle charging station available here :

https://www.data.gouv.fr/fr/datasets/fichier-consolide-des-bornes-de-recharge-pour-vehicules-electriques

## Build the project

Install requirement :
 - Docker

then execute :

```bash
docker-compose up
```

To execute in the background :
```bash
docker-compose up -d
```

To rebuild from sources :
```bash
docker-compose build  
```