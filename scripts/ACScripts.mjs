#!/usr/bin/env zx

import { cd } from 'zx/core'
import { spinner } from 'zx/experimental'

const contestName = argv.contestName
console.log(chalk.yellowBright("--- --- --- create Main project --- --- ---"))


const directory = getDirectory(contestName)

await within(async () => {

    await cd(`./${directory}`)
    await $`mkdir ${contestName}`

    await cd(`./${contestName}`)

    console.debug(process.cwd())

    // create projects.
    for (const item of ['A', 'B', 'C', 'D']) {

        const name = `${contestName}${item}`;

        // create project
        const res = await spinner(`creating ${name}...`, () => createProject(name))
        console.log(chalk.bgGreen.white(`✔ creating ${contestName}${item} SUCCESS! \t res : ${res.toString()}`))


        // add project to sln
        const res2 = await within(async () => {
            await cd(`../..`)
            await spinner(`add project ${name} to sln ...`, () => {
                $`dotnet sln add ./${directory}/${contestName}/${name}/${name}.csproj`
            })
        })
        console.log(chalk.bgGreen.white(`✔ add project to sln SUCCESS!`))

    }

})

async function createProject(projName) {
    return $`dotnet new AtCoderMain -o "${projName}"`
}

/**
 * 
 * @param {*} contestName 
 * @returns {string} targetDirectory
 */
function getDirectory(contestName) {

    const contestType = ["ABC", "ARC", "AGC"]

    const v = contestType.find(x => contestName.startsWith(x))

    if (!v) {
        console.error('cannot detect contest type.')
        throw new Error('cannot detect contest type.')
    }


    return v;

}