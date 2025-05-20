#pragma once
class Player : public Unit
{
public:
	Player();
	~Player();

	void Update() override;
	void Draw() override;

	void Jump();
};
