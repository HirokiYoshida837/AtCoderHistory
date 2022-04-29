#!/usr/bin/env zx

import { createProj } from "./Scripts/AtCoderScripts.mjs";

const contestName = argv.contestName
console.log(`contestName: ${contestName}`)

if (!contestName)
{
    console.error(`You should specific "contestName" with args "--contestName"`)
    throw new Error(`You should specific "contestName" with args "--contestName"`)
}

const problems = ['A', 'B', 'C', 'D']

await $`mkdir ${contestName}`
cd(`./${contestName}`)


await Promise.all(problems.map(async id =>
{
    return await createProj(`${contestName}${id}`)
}))


