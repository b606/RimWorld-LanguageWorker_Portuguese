#!/usr/bin/env bash
set -ex

MODNAME="RimWorld-LanguageWorker_Portuguese"

# Organisation of the folders
# BASEDIR
#  |-SLN_DIR : Monodevelop solution folder
#  |	+-Projects folders
#  |	+-Unit tests
#  |	+-Mod folder with compiled binaries
#  |	|	+-About
#  |	|	+-Assemblies
#  |	|	+-Source/Images
#  |	+-ModPackaging
#  |	+-Archives
#  |	+-scripts
#  |	+-Other stuffs...
#  +-...

# Alt: cut two slashes of dirname with "${P%/*/*}"
mydir=$(dirname "$(readlink -f $0)")
BASEDIR=$(cd "$mydir" && cd ../.. && pwd)
SLN_DIR=$(cd "$mydir" && cd .. && pwd)

# Location of RimWorld Mods folder
RELEASE_DIR="$HOME/.steam/steam/steamapps/common/RimWorld/Mods/"

# 1. Build all Monodevelop projects
cd "$SLN_DIR"
# Generate .pdb (unnecessary)
# mdtool build -c:DEBUG "$MODNAME.sln"
# Build all and copy to $RELEASE_DIR
mdtool build -c:RELEASE "$MODNAME.sln"
# Generate zip package
mdtool build -c:RELEASE ModPackaging/ModPackaging.mdproj

# 2. Test in game

# 3. Push to Steam Workshop, copy PublishedFileId.txt to the local repo.

# 4. Create repo on GitHub.
#   - git clone
#   - Copy the correct files in the local repo.
#   - Commit and push modification to ($MODNAME-fr)origin/master
#   - Verify texts
#   - Create release on github
#   - git pull to local repo

# 5. Push release to $RELEASE_DIR, then push to Steam Workshop


