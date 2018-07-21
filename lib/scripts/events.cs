//Events for AR's Deathrun
//Made by Cruxeis, BL_ID 35041

registerOutputEvent("GameConnection", "saveScore", "", false);
registerOutputEvent("GameConnection", "loadscore", "", false);
registerOutputEvent("GameConnection", "removeFromMini", "", false);
registerOutputEvent("GameConnection", "addToMini", "string 25 25", false);
registerOutputEvent("GameConnection", "setBuildingDisabled", "bool", false);
registerOutputEvent("GameConnection", "setPaintingDisabled", "bool", false);
registerOutputEvent("Minigame", "changeTeamDatablock", "string 100 100" TAB "datablock PlayerData", false);
registerOutputEvent("Player", "doHeadUp", "", false);
registerOutputEvent("Player", "stopHeadUp", "", false);
registerOutputEvent("Minigame", "chooseRandPlayer", "string 150 150", false);
registerOutputEvent("Minigame", "allJoinTeam", "string 150 150", false);
registerOutputEvent("fxDTSBrick", "fetchAll", "list None 0 North 1 East 2 South 3 West 4", false);
registerOutputEvent("GameConnection", "teleportSlayerTeam", "string 175 175	string 175 175", false);
registerOutputEvent("GameConnection", "loadEnvironment", "string 100 100", false);