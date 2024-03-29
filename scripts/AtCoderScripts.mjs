﻿export async function createProj(ProjName, needTest) {

    console.log("--- --- --- create Main project --- --- ---")
    let mainCreateCode = await $`dotnet new AtCoderMain -o "${ProjName}"`

    if (needTest) {

        console.log("--- --- --- create Test project --- --- ---")
        let testCreateCode = await $`dotnet new AtCoderTest -o "${ProjName}".Test`

        return await Promise.all([mainCreateCode, testCreateCode])
            .then(async res => {
                // 何故か文字化けする。
                await $`dotnet add "${ProjName}".Test/"${ProjName}".Test.csproj reference "${ProjName}"/"${ProjName}".csproj`
                await $`dotnet remove "${ProjName}".Test/"${ProjName}".Test.csproj reference "..\ABCXXX\ABCXXX.csproj"`
            })

    } else {
        return mainCreateCode;
    }

}