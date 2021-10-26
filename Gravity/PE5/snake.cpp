#include "snake.h";
#include <iostream>
#include <conio.h>
#include <stdlib.h>

// updates our world in real time
void update(sf::Clock* clock, b2World* world)
{
	sf::Time dt = clock->getElapsedTime();
	clock->restart();
	world->Step(dt.asSeconds(), 6, 2);
}

//prints target's and snake's current x and y positions
void display(b2Body* player, b2Body* target)
{
	b2Vec2 positionP = player -> GetPosition();
	b2Vec2 positionT = target -> GetPosition();
	std::cout << "Target " << positionT.x << ", " << positionT.y << " --> Snake "<< positionP.x << ", " << positionP.y << std::endl;
}

void applyForces(b2Body* player)
{
	// if a key is down, apply appropriate force 

	if (sf::Keyboard::isKeyPressed(sf::Keyboard::D))
	{
		player->ApplyForceToCenter(b2Vec2(50.0f, 0.0f), true);
	}
	if (sf::Keyboard::isKeyPressed(sf::Keyboard::A))
	{
		player->ApplyForceToCenter(b2Vec2(-50.0f, 0.0f), true);
	}
	if (sf::Keyboard::isKeyPressed(sf::Keyboard::W))
	{
		player->ApplyForceToCenter(b2Vec2(0.0f, 100.0f), true);
	}
	if (sf::Keyboard::isKeyPressed(sf::Keyboard::S))
	{
		player->ApplyForceToCenter(b2Vec2(0.0f, -100.0f), true);
	}
}

int moveTarget()
{
	// create rand int between 0 and 500
	return rand() % 500;
}