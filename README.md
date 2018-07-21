# Description

This repo contains a very simple F# app that uses [Suave.IO](https://suave.io/) to serve a trivial web app that
has a form that can be used to convert a string to uppercase via a GET call to `/api/toUpper/<string>`.
A docker image is built and deployed to Heroku.

# Deploying

```
heroku container:push web
heroku container:release web
```

# Notes

## Dockerfile

It must be called `Dockerfile`. I initially called it `dockerfile` which caused `heroku container:push web` to fail:

```
$ heroku container:push web
 ▸    No images to push
```

## heroku update

Initially, `heroku container:release web` was not a recognised command. I needed to update the Heroku CLI:

```
heroku update
```

Then it was fine.
