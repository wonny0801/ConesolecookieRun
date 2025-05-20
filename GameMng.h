#pragma once
class GameMng
{
public:
	GameMng();
	~GameMng();

	Player player;

	void Update();
	void Draw();
};
extern GameMng gamemng;
