#!/usr/bin/env bash
# Configura o Git para usar os hooks versionados em .githooks/
git config core.hooksPath .githooks
chmod +x .githooks/commit-msg
echo "✅ Git hooks configurados. Commits agora serão validados."
