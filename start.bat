@echo off
setlocal enabledelayedexpansion
chcp 65001 >nul
title PayFlow - Ambiente Docker

echo.
echo ============================================================
echo                 PAYFLOW - INICIANDO AMBIENTE
echo ============================================================
echo.

echo [1/4] Verificando se o Docker esta em execucao...
docker info >nul 2>&1
if errorlevel 1 (
    echo.
    echo [ERRO] Docker Desktop nao esta rodando.
    echo         Abra o Docker Desktop e tente novamente.
    echo.
    pause
    exit /b 1
)
echo       OK - Docker esta rodando.
echo.

echo [2/4] Buildando imagens e subindo os containers...
echo       ------------------------------------------------------
docker compose up -d --build
if errorlevel 1 (
    echo.
    echo [ERRO] Falha ao subir os containers. Verifique o log acima.
    echo.
    pause
    exit /b 1
)
echo       ------------------------------------------------------
echo       OK - Containers no ar.
echo.

echo [3/4] Aguardando servicos ficarem saudaveis...
set /a contador=0
:wait_loop
for /f "tokens=*" %%i in ('docker inspect --format="{{.State.Health.Status}}" payflow-sqlserver 2^>nul') do set sql_status=%%i
if "!sql_status!"=="healthy" goto healthy
set /a contador+=1
if !contador! geq 15 (
    echo       [AVISO] SQL Server ainda nao respondeu como saudavel.
    echo               Prosseguindo mesmo assim, verifique os logs se algo falhar.
    goto healthy
)
timeout /t 2 >nul
goto wait_loop
:healthy
echo       OK - Servicos prontos.
echo.

echo [4/4] Status atual dos containers:
echo       ------------------------------------------------------
docker compose ps
echo       ------------------------------------------------------
echo.

echo ============================================================
echo                  AMBIENTE DISPONIVEL EM:
echo ============================================================
echo.
echo   API .....................  http://localhost:8080
echo   Swagger .................  http://localhost:8080/swagger/index.html
echo   SQL Server ..............  localhost,1433
echo.
echo ============================================================
echo   PayFlow iniciado com sucesso!
echo ============================================================
echo.

pause