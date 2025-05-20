#include "include.h"

Unit::Unit()
{
	x = 0;
	y = 0;
	body = ' ';
	fColor = WHITE;
	bColor = BLACK;
	isAlive = false;
}

Unit::~Unit()
{
}

void Unit::Update()
{
}

void Unit::Draw()
{
	DrawChar(x, y, body, fColor, bColor);
}

void Unit::Enable(int x, int y)
{
	this->x = x;
	this->y = y;
	this->isAlive = true;
}

void Unit::Disable()
{
	this->isAlive = false;
}
