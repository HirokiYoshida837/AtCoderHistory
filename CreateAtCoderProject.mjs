#!/usr/bin/env zx

import { createProj } from "./Scripts/AtCoderScripts.mjs";


const projectName = argv.projectName
console.log(`projectName: ${projectName}`)

if (!projectName)
{
    console.error(`You should specific "projectName" with args "--projectName"`)
    throw new Error(`You should specific "projectName" with args "--projectName"`)
}


await createProj(projectName)
