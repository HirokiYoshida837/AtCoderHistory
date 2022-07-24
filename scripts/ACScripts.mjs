#!/usr/bin/env zx

import { cd } from 'zx/core'
import { spinner } from 'zx/experimental'

const contestName = argv.contestName
console.log(chalk.yellowBright("--- --- --- create Main project --- --- ---"))

await $`mkdir ${contestName}`

await within(async () => {

    await cd(`./${contestName}`)

    console.debug(process.cwd())

    // create projects.
    for (const item of ['A', 'B', 'C', 'D']) {
        const res = await spinner(`creating ${contestName}${item}...`, () => createProject(`${contestName}${item}`))
        console.log(chalk.bgGreen.white(`✔ creating ${contestName}${item} SUCCESS! \t res : ${res.toString()}`))
    }

})

await sleep(200)

// create projects.
for (const item of ['A', 'B', 'C', 'D']) {
    const res = await spinner(`add project to sln ..`, () => $`dotnet sln add ${contestName}/${contestName}${item}/${contestName}${item}.csproj`)
    console.log(chalk.bgGreen.white(`✔ add project to sln SUCCESS! \t res : ${res.toString()}`))
}

async function createProject(projName) {
    return $`dotnet new AtCoderMain -o "${projName}"`
}