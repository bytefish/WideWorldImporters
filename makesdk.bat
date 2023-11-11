@echo off

:: Licensed under the MIT license. See LICENSE file in the project root for full license information.

:: Kiota Executable
set KIOTA_EXECUTABLE=kiota

:: Parameters for the Code Generator
set PARAM_OPENAPI_SCHEMA="https://localhost:5000/odata/openapi.json"
set PARAM_LANGUAGE=csharp
set PARAM_NAMESPACE=WideWorldImporters.Shared.ApiSdk
set PARAM_OUT_DIR=%~dp0/src/WideWorldImporters.Shared/WideWorldImporters.Shared.ApiSdk
set PARAM_LOG_LEVEL=Trace

:: Run the "kiota generate" Command
%KIOTA_EXECUTABLE% generate^
    --openapi %PARAM_OPENAPI_SCHEMA%^
    --language %PARAM_LANGUAGE%^
    --namespace-name %PARAM_NAMESPACE%^
    --log-level %PARAM_LOG_LEVEL%^
    --output %PARAM_OUT_DIR%