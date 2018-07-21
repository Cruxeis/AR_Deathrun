//Operative functions for AR's Deathrun
//Made by Cruxeis, BL_ID 35041

function printPointsLoop()
{
	if(getMinigameByTitle("Deathrun").numMembers == 0)
	{
		bottomPrintAll("");
		cancel($printPointsSched);
		return;
	}
	%count = clientGroup.getCount();
	%runners = getMinigameByTitle("Deathrun").getTeam("Runners").getNumLiving();
	if(isObject(%death = getMinigameByTitle("Deathrun").getTeam("Death").member[0]))
		%deathName = getMinigameByTitle("Deathrun").getTeam("Death").member[0].getPlayerName();
	for(%i = 0; %i < %count; %i++)
	{
		%score[%i] = clientGroup.getObject(%i).score; 
		if(!getMinigameByTitle("Deathrun").isResetting)
			bottomPrint(clientGroup.getObject(%i), "\c3Runners Alive\c6:" SPC %runners @ "<just:right>\c4Score\c6:" SPC %score[%i] @ "<br><just:left>\c7Death\c6:" SPC %deathName @ "<just:Right><font:impact:18>\c0cancelbrick \c6 to spectate");
	}
	$printPointsSched = schedule(500, 0, printPointsLoop);
}

function getMinigameByTitle(%title)
{
	if(%title $= "" || %title $= " ")
		return false;
	if(isObject(Slayer_MinigameHandlerSG))
	{
		for(%i = 0; %i < Slayer_MinigameHandlerSG.getCount(); %i++)
		{
			%mini = Slayer_MinigameHandlerSG.getObject(%i);
			if(%mini.title $= %title)
				return %mini;
		}
	}
	if(isObject(MiniGameGroup))
	{
		for(%i = 0; %i < MiniGameGroup.getCount(); %i++)
		{
			%mini = MiniGameGroup.getObject(%i);
			if(%mini.title $= %title)
				return %mini;
		}
	}
	else
		return false;
}

function rotator_loadMap(%map)
{
	$newrotatormap = trim(%map);
	%file = "config/rotatorMaps/" @ $newrotatormap @ ".bls";
	serverDirectSaveFileLoad(%file, 3, "", 2, 1);
}

function rotator_loadEnvironment(%name)
{
	if(!isFile("config/rotatorEnvironments/" @ %name @ ".cs"))
		return messageAll('', "\c3Rotator load environment \c0error\c6: File not found");
	else
		loadEnvironment("config/rotatorEnvironments/" @ %name @ ".cs");
}

//not made by me or AR
function loadEnvironment(%file)
{
    GameModeGuiServer::parseGameModeFile(%file, 1);

    EnvGuiServer::getIdxFromFilenames();
    EnvGuiServer::setSimpleMode();

    if (!$EnvGuiServer::SimpleMode)
    {
        EnvGuiServer::fillAdvancedVarsFromSimple();
        EnvGuiServer::setAdvancedMode();
    }
}

//not made by me or AR
function setEnvironment(%varName, %value)
{
    // if ($EnvGuiServer["::" @ %varName] $= %value)
    //     return;

    switch$ (%varName)
    {
    case "SimpleMode":
        $EnvGuiServer::SimpleMode = mClamp(%value, 0, 1);
        EnvGuiServer::setSimpleMode();

        if (!$EnvGuiServer::SimpleMode)
        {
            if (!$EnvGuiServer::HasSetAdvancedOnce)
                EnvGuiServer::readAdvancedVarsFromSimple();

            EnvGuiServer::setAdvancedMode();
        }

    case "SkyIdx":
        $EnvGuiServer::SkyIdx = mClamp(%value, 0, $EnvGuiServer::SkyCount);
        setSkyBox($EnvGuiServer::Sky[$EnvGuiServer::SkyIdx]);

    case "WaterIdx":
        $EnvGuiServer::WaterIdx = mClamp(%value, 0, $EnvGuiServer::WaterCount);
        setWater($EnvGuiServer::Water[$EnvGuiServer::WaterIdx]);

    case "GroundIdx":
        $EnvGuiServer::GroundIdx = mClamp(%value, 0, $EnvGuiServer::GroundCount);
        setGround($EnvGuiServer::Ground[$EnvGuiServer::GroundIdx]);

    case "SunFlareTopIdx":
        $EnvGuiServer::SunFlareTopIdx = mClamp(%value, 0, $EnvGuiServer::SunFlareCount);
        %top = $EnvGuiServer::SunFlareTop[$EnvGuiServer::SunFlareTopIdx];
        %bottom = $EnvGuiServer::SunFlareBottom[$EnvGuiServer::SunFlareBottomIdx];
        SunLight.setFlareBitmaps(%top, %bottom);

    case "SunFlareBottomIdx":
        $EnvGuiServer::SunFlareBottomIdx = mClamp(%value, 0, $EnvGuiServer::SunFlareCount);
        %top = $EnvGuiServer::SunFlareTop[$EnvGuiServer::SunFlareTopIdx];
        %bottom = $EnvGuiServer::SunFlareBottom[$EnvGuiServer::SunFlareBottomIdx];
        SunLight.setFlareBitmaps(%top, %bottom);

    case "DayOffset":
        $EnvGuiServer::DayOffset = mClampF(%value, 0, 1);
        DayCycle.setDayOffset($EnvGuiServer::DayOffset);

    case "DayLength":
        $EnvGuiServer::DayLength = mClamp(%value, 0, 86400);
        DayCycle.setDayLength($EnvGuiServer::DayLength);

    case "DayCycleEnabled":
        $EnvGuiServer::DayCycleEnabled = mClamp(%value, 0, 1);
        DayCycle.setEnabled($EnvGuiServer::DayCycleEnabled);

    case "DayCycleIdx":
        $EnvGuiServer::DayCycleIdx = mClamp(%value, 0, $EnvGuiServer::DayCycleCount);
        %dayCycle = $EnvGuiServer::DayCycle[$EnvGuiServer::DayCycleIdx];
        echo("server setting daycycle to " @ %dayCycle);
        loadDayCycle(%dayCycle);

    case "SunAzimuth":
        $EnvGuiServer::SunAzimuth = mClampF(%value, 0, 360);
        Sun.azimuth = $EnvGuiServer::SunAzimuth;
        Sun.sendUpdate();

    case "SunElevation":
        $EnvGuiServer::SunElevation = mClampF(%value, -10, 190);
        Sun.elevation = $EnvGuiServer::SunElevation;
        Sun.sendUpdate();

    case "DirectLightColor":
        $EnvGuiServer::DirectLightColor = getColorF(%value);
        Sun.color = $EnvGuiServer::DirectLightColor;
        Sun.sendUpdate();

    case "AmbientLightColor":
        $EnvGuiServer::AmbientLightColor = getColorF(%value);
        Sun.ambient = $EnvGuiServer::AmbientLightColor;
        Sun.sendUpdate();

    case "ShadowColor":
        $EnvGuiServer::ShadowColor = getColorF(%value);
        Sun.shadowColor = $EnvGuiServer::DirectLightColor;
        Sun.sendUpdate();

    case "SunFlareColor":
        $EnvGuiServer::SunFlareColor = getColorF(%value);
        SunLight.color = $EnvGuiServer::SunFlareColor;
        SunLight.sendUpdate();

    case "SunFlareSize":
        $EnvGuiServer::SunFlareSize = mClampF(%value, 0, 10);
        // Badspot, why not just SunLight.setFlareSize(...);?
        SunLight.flareSize = $EnvGuiServer::SunFlareSize;
        SunLight.sendUpdate();

    case "SunFlareIdx":
        $EnvGuiServer::SunFlareIdx = mClamp(%value, 0, $EnvGuiServer::SunFlareCount);
        // ... what? Why does this exist? There is no "SunFlareIdx" system.
        // Get outta' here.

    case "VisibleDistance":
        $EnvGuiServer::VisibleDistance = mClampF(%value, 0, 1000);
        Sky.visibleDistance = $EnvGuiServer::VisibleDistance;
        Sky.sendUpdate();

    case "FogDistance":
        $EnvGuiServer::FogDistance = mClampF(%value, 0, 1000);
        Sky.fogDistance = $EnvGuiServer::FogDistance;
        Sky.sendUpdate();

    case "FogHeight":
        $EnvGuiServer::FogHeight = mClampF(%value, 0, 1000);
        // Nothing to see here...

    case "FogColor":
        $EnvGuiServer::FogColor = getColorF(%value);
        Sky.fogColor = $EnvGuiServer::FogColor;
        Sky.sendUpdate();

    case "WaterColor":
        $EnvGuiServer::WaterColor = getColorF(%value);

        if (isObject(WaterPlane))
        {
            WaterPlane.color = getColorI($EnvGuiServer::WaterColor);
            WaterPlane.blend = getWord(WaterPlane.color, 3) < 255;
            WaterPlane.sendUpdate();
        }

        updateWaterFog();

    case "WaterHeight":
        $EnvGuiServer::WaterHeight = mClampF(%value, 0, 100);

        if (isObject(WaterPlane))
        {
            %pos = getWords(GroundPlane.getTransform(), 0, 2);
            %pos = vectorAdd(%pos, "0 0" SPC $EnvGuiServer::WaterHeight);

            WaterPlane.setTransform(%pos SPC "0 0 1 0");
            WaterPlane.sendUpdate();

            updateWaterFog();

            if (isObject(WaterZone))
            {
                %pos = vectorSub(%pos, "0 0 99.5");
                %pos = vectorSub(%pos, "500000 -500000 0");
                WaterZone.setTransform(%pos SPC "0 0 1 0");
            }
        }

    case "UnderWaterColor":
        $EnvGuiServer::UnderWaterColor = getColorF(%value);

        if (isObject(WaterZone))
        {
            WaterZone.setWaterColor($EnvGuiServer::UnderWaterColor);
        }

    case "SkyColor":
        $EnvGuiServer::SkyColor = getColorF(%value);
        // Something is off about this one...
        Sky.skyColor = $EnvGuiServer::SkyColor;
        Sky.sendUpdate();

    // Should probably combine this into one
    // case "WaterScrollX" or "WaterScrollY":
    case "WaterScrollX":
        $EnvGuiServer::WaterScrollX = mClampF(%value, -10, 10);
        $EnvGuiServer::WaterScrollY = mClampF($EnvGuiServer::WaterScrollY, -10, 10);

        if (isObject(WaterPlane))
        {
            WaterPlane.scrollSpeed = $EnvGuiServer::WaterScrollX SPC $EnvGuiServer::WaterScrollY;
            WaterPlane.sendUpdate();
        }

        if (isObject(WaterZone))
        {
            %fx = $EnvGuiServer::WaterScrollX * 414;
            %fy = $EnvGuiServer::WaterScrollY * -414;

            WaterZone.appliedForce = %fx SPC %fy SPC 0;
            WaterZone.sendUpdate();
        }

    case "WaterScrollY":
        $EnvGuiServer::WaterScrollY = mClampF(%value, -10, 10);
        $EnvGuiServer::WaterScrollX = mClampF($EnvGuiServer::WaterScrollX, -10, 10);

        if (isObject(WaterPlane))
        {
            WaterPlane.scrollSpeed = $EnvGuiServer::WaterScrollX SPC $EnvGuiServer::WaterScrollY;
            WaterPlane.sendUpdate();
        }

        if (isObject(WaterZone))
        {
            %fx = $EnvGuiServer::WaterScrollX * 414;
            %fy = $EnvGuiServer::WaterScrollY * -414;

            WaterZone.appliedForce = %fx SPC %fy SPC 0;
            WaterZone.sendUpdate();
        }

    case "GroundColor":
        $EnvGuiServer::GroundColor = getColorF(%value);

        if (isObject(GroundPlane))
        {
            GroundPlane.color = getColorI($EnvGuiServer::GroundColor);
            GroundPlane.blend = getWord(GroundPlane.color, 3) < 255;
            GroundPlane.sendUpdate();

            Sky.renderBottomTexture = getWord(GroundPlane.color, 3) <= 0;
            Sky.noRenderBans = Sky.renderBottomTexture;
            Sky.sendUpdate();
        }

    case "GroundScrollX":
        $EnvGuiServer::GroundScrollX = mClampF(%value, -10, 10);
        $EnvGuiServer::GroundScrollY = mClampF($EnvGuiServer::GroundScrollY, -10, 10);

        if (isObject(GroundPlane))
        {
            GroundPlane.scrollSpeed = $EnvGuiServer::GroundScrollX SPC $EnvGuiServer::GroundScrollY;
            GroundPlane.sendUpdate();
        }

    case "GroundScrollY":
        $EnvGuiServer::GroundScrollY = mClampF(%value, -10, 10);
        $EnvGuiServer::GroundScrollX = mClampF($EnvGuiServer::GroundScrollX, -10, 10);

        if (isObject(GroundPlane))
        {
            GroundPlane.scrollSpeed = $EnvGuiServer::GroundScrollX SPC $EnvGuiServer::GroundScrollY;
            GroundPlane.sendUpdate();
        }

    case "VignetteMultiply":
        $EnvGuiServer::VignetteMultiply = mClamp(%value, 0, 1);
        sendVignetteAll();

    case "VignetteColor":
        $EnvGuiServer::VignetteColor = getColorF(%value);
        sendVignetteAll();

    default:
        return 0;
    }

    return 1;
}

function writeToFile(%path, %line)
{
	%file = new fileObject();
	%file.openForAppend(%path);
	%file.writeLine(%line);
	%file.close();
	%file.delete();
}

function staffShutdown()
{
	%count = clientGroup.getCount();
	for(%i = %count; %i > 0; %i--)
		if((%client = clientGroup.getObject(%i)).getAdminLevel() < 1)
			%client.delete();
}

//not made by me or AR
function adminChatPrepString(%message) 
{
    %message = StripMLControlChars(%message);
    %message = trim(%message);


    for(%i = 0; %i < getWordCount(%message); %i++) {
        %word = getWord(%message, %i);

        if(strpos(%word, "http://") == 0 || strpos(%word, "https://") == 0) {
            %url = getSubStr(%word, strpos(%word, "://")+3, strlen(%word));
            %link = "<a:" @ %word @ ">" @ %url @ "</a>";
            %message = setWord(%message, %i, %link);
        }
    }

    return %message;
}

package ARDeathrun_OpPackage {

function serverLoadSaveFile_End()
{
	Parent::serverLoadSaveFile_End();
	%runners = getMinigameByTitle("Deathrun").getTeam("Runners");
	%runners.schedule(1000, respawnAll);
	%runners.centerPrintAll();
	%map = $newrotatormap;
	if(%map $= "Creative")
		$intermissionBrick.disappear(-1);
	if(%map $= "Skylands")
		$Skylandsbrick.disappear(-1);
	if(%map $= "City")
		$Citybrick.disappear(-1);
	if(%map $= "Biomes")
		$Biomesbrick.disappear(-1);
}

};

activatePackage(ARDeathrun_OpPackage);