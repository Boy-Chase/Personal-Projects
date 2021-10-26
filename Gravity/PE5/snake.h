#pragma once
#define SFML_STATIC
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <Box2D/Box2D.h>

void update(sf::Clock* clock, b2World* world);
void display(b2Body* player, b2Body* target);
void applyForces(b2Body* player);
int moveTarget();