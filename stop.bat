@echo off
setlocal enabledelayedexpansion
chcp 65001 >nul
title PayFlow - Ambiente Docker

echo.
echo ============================================================
echo                 PAYFLOW - PARANDO AMBIENTE
echo ============================================================
echo.

echo [1/2] Containers em execucao antes de parar:
echo       ------------------------------------------------------
docker compose ps
echo       ------------------------------------------------------
echo.

echo [2/2] Parando e removendo containers, networks...
docker compose down
if errorlevel 1 (
    echo.
    echo [ERRO] Falha ao parar os containers. Verifique o log acima.
    echo.
    pause
    exit /b 1
)
echo.

echo ============================================================
echo   PayFlow parado com sucesso!
echo   Os dados do banco continuam salvos no volume Docker.
echo ============================================================
echo.

pause