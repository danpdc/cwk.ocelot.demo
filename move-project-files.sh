#!/usr/bin/env bash

set -e -x

pushd ${BASH_SOURCE%/*}

for file in $(ls *.csproj); do mkdir -p $1/${file%.*}/ && mv $file $1/${file%.*}/; done

popd
