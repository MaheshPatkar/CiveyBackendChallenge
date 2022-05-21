# Backend Code Challenge

This repository contains a simple voting API written in C#. It has polls and answers, and you need to extend it to allow for storing votes.

The challenge should not take longer than around two hours.

## Running the application

To run this application, you will need to install Microsoft .NET 5.0 alongside with docker.

## Seeding the database

To initialize the database, set the environment variable `DBInit` to `True` in launchSettings.json. Once the database is seeded, don't forget to set it back to `False`.

## The tasks

You can choose whatever framework you think fit the tasks best. Please add as many tests as you feel is necessarry.

### Storing Votes

- You should add an endpoint where you can store votes cast to the answers in the database.

### Displaying results

- You should add a `/polls/{id}` endpoint to return the poll details from the database and the current result ratios for cast votes.
- You should alter the `/polls` endpoint to fetch the poll details from the database.
- You should add pagination support to the `/polls` endpoint.
- You should add search support (searching the poll and answer titles) for the `/polls` endpoint.

## Submission
Please upload you submission to a private repository at GitHub and invite us to it.

Please commit at the latest in 180 minutes. If you want to commit afterwards as well, feel free, but we need to see what you had at time limit.
