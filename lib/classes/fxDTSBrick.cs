//fxDTSBrick class for AR's Deathrun
//Made by Cruxeis, BL_ID 35041

function fxDTSBrick::fetchAll(%this, %rotation, %client)
{
	switch(%rotation)
	{
		case 0:
		for(%i = 0; %i < clientGroup.getCount(); %i++)
		{
			if(isObject(%player = clientGroup.getObject(%i).player))
				%player.setTransform(VectorAdd(%this.getTransform(), "0 0" SPC 0.1 * %this.getDatablock().brickSizeZ));
				%player.teleportEffect();
		}
		case 1:
		for(%i = 0; %i < clientGroup.getCount(); %i++)
		{
			if(isObject(%player = clientGroup.getObject(%i).player))
				%player.setTransform(VectorAdd(%this.getTransform(), "0 0" SPC 0.1 * %this.getDatablock().brickSizeZ) SPC "0 0 0 0");
				%player.teleportEffect();
		}
		case 2:
		for(%i = 0; %i < clientGroup.getCount(); %i++)
		{
			if(isObject(%player = clientGroup.getObject(%i).player))
				%player.setTransform(VectorAdd(%this.getTransform(), "0 0" SPC 0.1 * %this.getDatablock().brickSizeZ) SPC "0 0 1" SPC ($pi / 2));
				%player.teleportEffect();
		}
		case 3:
		for(%i = 0; %i < clientGroup.getCount(); %i++)
		{
			if(isObject(%player = clientGroup.getObject(%i).player))
				%player.setTransform(VectorAdd(%this.getTransform(), "0 0" SPC 0.1 * %this.getDatablock().brickSizeZ) SPC "0 0 1" SPC $pi);
				%player.teleportEffect();
		}
		case 4:
		for(%i = 0; %i < clientGroup.getCount(); %i++)
		{
			if(isObject(%player = clientGroup.getObject(%i).player))
				%player.setTransform(VectorAdd(%this.getTransform(), "0 0" SPC 0.1 * %this.getDatablock().brickSizeZ) SPC "0 0 1" SPC ((3 * $pi) / 2));
				%player.teleportEffect();
		}
	}
}