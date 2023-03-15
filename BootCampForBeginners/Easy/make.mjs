#!/usr/bin/env zx

import {cd} from 'zx/core'
import {spinner} from 'zx/experimental'

async function createProject(projName) {
    return $`dotnet new AtCoderMain -o "${projName}"`
}

async function main() {

    for (let i = 1; i <= 100; i++) {

        if (i == 1 || i == 3 || i == 6 || i == 9) {
            continue;
        }

        const padNum = String(i).padStart(3, '0');

        const name = `Easy_${padNum}`

        // create Project
        const res = await spinner(`creating ${name}...`, () => createProject(name))
        console.log(chalk.bgGreen.white(`✔ creating ${name} SUCCESS! \t res : ${res.toString()}`))


    }
}

await main();