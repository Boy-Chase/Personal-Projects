// PE5.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <Box2D/Box2D.h>
#define SFML_STATIC
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include "snake.h";
using namespace std;

// player shape
sf::RectangleShape rectangle(sf::Vector2f(50, 50));

// target shape
sf::CircleShape circle(15);

int main()
{
    // the players score
    int score = 0;

    // setting up text for score
    sf::Text text;
    sf::Font font;
    if (!font.loadFromFile("arial.ttf"))
    {
        cout << "font failed to load" << endl;
        return 0;
    }
    text.setFont(font);
    text.setString("Score is: " + score);
    text.setCharacterSize(30);
    text.setFillColor(sf::Color::Magenta);

    // setting up text for directions
    sf::Text directions;
    directions.setFont(font);
    directions.setString("Let's play Gravity Snake: A moves left. \nD moves right. W moves up. S moves down. G swaps gravity.");
    directions.setCharacterSize(15);
    directions.setFillColor(sf::Color::White);
    directions.setPosition(0, 560);

    // create the window
    sf::RenderWindow window(sf::VideoMode(600, 600), "My window");

    //gravity
    b2Vec2 gravity(0.0f, -9.81f);
    b2World world(gravity);

    //ground established
    b2BodyDef groundBodyDef;
    groundBodyDef.position.Set(2.0f, -14.0f);
    b2Body* groundBody = world.CreateBody(&groundBodyDef);

    //shaping ground
    b2PolygonShape groundBox;
    groundBox.SetAsBox(5.0f, 5.0f);
    groundBody->CreateFixture(&groundBox, 0.0f);

    //roof established
    b2BodyDef roofBodyDef;
    roofBodyDef.position.Set(1.0f, 5.0f);
    b2Body* roofBody = world.CreateBody(&roofBodyDef);

    //shaping roof
    b2PolygonShape roofBox;
    roofBox.SetAsBox(5.0f, 5.0f);
    roofBody->CreateFixture(&roofBox, 0.0f);

    //left wall established
    b2BodyDef leftBodyDef;
    leftBodyDef.position.Set(-13.0f, -9.0f);
    b2Body* leftBody = world.CreateBody(&leftBodyDef);

    //shaping left
    b2PolygonShape leftBox;
    leftBox.SetAsBox(10.0f, 10.0f);
    leftBody->CreateFixture(&leftBox, 0.0f);

    //right wall established
    b2BodyDef rightBodyDef;
    rightBodyDef.position.Set(17.0f, -9.0f);
    b2Body* rightBody = world.CreateBody(&rightBodyDef);

    //shaping right
    b2PolygonShape rightBox;
    rightBox.SetAsBox(10.0f, 10.0f);
    rightBody->CreateFixture(&rightBox, 0.0f);

    //player box established
    b2BodyDef bodyDef;
    bodyDef.type = b2_dynamicBody;
    bodyDef.position.Set(0.0f, 1.5f);
    b2Body* body = world.CreateBody(&bodyDef);

    //sizing box
    b2PolygonShape dynamicBox;
    dynamicBox.SetAsBox(0.5f, 0.5f);

    b2FixtureDef fixtureDef;
    fixtureDef.shape = &dynamicBox;
    fixtureDef.density = 1.0f;
    fixtureDef.friction = 0.3f;
    body->CreateFixture(&fixtureDef);

    //target established
    b2BodyDef targetBodyDef;
    targetBodyDef.position.Set(-5.0f, 1.0f);
    b2Body* targetBody = world.CreateBody(&targetBodyDef);

    //shaping target
    b2PolygonShape targetBox;
    targetBox.SetAsBox(0.25f, 0.25f);
    targetBody->CreateFixture(&targetBox, 0.0f);

    //clock
    bool running = true;
    sf::Clock deltaClock;
    b2Vec2 position();

    // starting positions
    rectangle.setPosition(300, 300);

    circle.setPosition(300, 250);

    bool gravitySwap = false;

    // run the program as long as the window is open
    while (window.isOpen())
    {
        // checks if Player is close to target
        if ( sqrt( ( (circle.getPosition().x - rectangle.getPosition().x) * (circle.getPosition().x - rectangle.getPosition().x) ) + (circle.getPosition().y - rectangle.getPosition().y) * (circle.getPosition().y - rectangle.getPosition().y) ) < 40)
        {
            // work on changing position
            circle.setPosition( moveTarget() , moveTarget() );
            score++;
            text.setString("Score is: " + std::to_string(score));
        }

        // check all the window's events that were triggered since the last iteration of the loop
        sf::Event event;
        while (window.pollEvent(event))
        {
            // "close requested" event: we close the window
            if (event.type == sf::Event::Closed)
                window.close();
        }

        // clear the window with black color
        window.clear(sf::Color::Black);
        
        // draw everything here...
 
        // changes color when score reaches 3
        if (2 < score)
        {
            // color set
            rectangle.setFillColor(sf::Color(100, 250, 50));
        }
        else
        {
            // color set
            rectangle.setFillColor(sf::Color(50, 50, 50));
        }

        circle.setFillColor(sf::Color(200, 100, 100));;

        //update world
        update(&deltaClock, &world);

        //movement
        applyForces(body);

        //gravity swap input
        if (sf::Keyboard::isKeyPressed(sf::Keyboard::G))
        {
            gravitySwap = !gravitySwap;

            //updates gravity
            if (gravitySwap)
            {
                world.SetGravity(b2Vec2(0, -9.81f));
            }
            else
            {
                world.SetGravity(b2Vec2 (0, 9.81f));
            }
        }

        //displays position
        
        rectangle.setPosition((body->GetPosition().x + 2.5) * 60, body->GetPosition().y * -60);

        //drawing to window
        window.draw(rectangle);

        window.draw(circle);

        window.draw(text);

        window.draw(directions);

        // window.draw(...);

        // end the current frame
        window.display();
    }

    return 0;
}
  

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
