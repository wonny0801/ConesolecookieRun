#include "include.h"

Player::Player()
{
	x = 3;
	y = 29;
	body = 'R';
	fColor = WHITE;
	bColor = BLACK;
	isAlive = true;

}

Player::~Player()
{
}

void Player::Update()
{
	Jump();
}

void Player::Draw()
{
	DrawChar(x, y, body, fColor, bColor);
}

void Player::Jump()
{
}