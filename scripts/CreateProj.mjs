#!/usr/bin/env zx

import {createProj} from "./AtCoderScripts.mjs";

$`set -eux`

const contestName = argv.contestName
console.log(`contestName: ${contestName}`)

await $`mkdir ${contestName}`
await cd(`./${contestName}`)

await $`pwd`

await Promise.all(['A', 'B', 'C', 'D'].map(async id => {
    return await createProj(`${contestName}${id}`)
}))