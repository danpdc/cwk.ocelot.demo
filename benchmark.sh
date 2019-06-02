#!/usr/bin/env bash

set -e -x

pushd ${BASH_SOURCE%/*}

docker-compose build benchmark
docker-compose run --rm benchmark dotnet run -c Release

popd
