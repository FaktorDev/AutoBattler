# Description [LEGACY]
<a href="LICENSE"><img src="https://img.shields.io/badge/license-Attribution--NonCommercial%204.0%20International,%20see%20LICENSE%20file-blue"></a>

This project is a complex one, with various other projects responsible for their own tasks. You can read the code of each of them. But I will not provide the template of the database used for the game and where all the information is stored. If you are interested in it, I am ready to help you.
mykhailo.honchar5@gmail.com

## Contents
1. [Description](#Description)
2. [Projects](#Projects)
3. [Why does this project exist?](#Why-does-this-project-exist?)
4. [Features](#Features)
5. [How to use it](#How-to-use-it)
6. [For the player](#For-the-player)
7. [Contacts](#Contacts)
8. [License](#License)
## Projects
| Name          | Description    |
| :-----------: |:-------------|
|Game Logic| A project in which all the game logic is stored. The logic of configurations from Google Sheets can be found here. |
|Game API| Since it is an online game, it has a server. This project is responsible for it, and with the help of this project, you can test the auto-battle system. |
## Why does this project exist?
There are several reasons for this:
1. I am honing my knowledge on this project.
2. I want to create my own online game, a strategy in which I can dynamically create content.
# Features
### - :bar_chart: **Game configuration via Google Sheets**: The game uses Google Sheets to store character, enemy, item, and adventure configurations. This makes it easy to edit and add new content.
  
  - [Characters](https://docs.google.com/spreadsheets/d/1-kQhNXS615orKscKRtoWPQWgkRVdVD8irhbGeJkgU0E/edit?usp=sharing)

### - :wrench: **Flexible Combat System**: The battle system allows you to create a variety of battle configurations, which makes the game interesting and dynamic.
  
### - :outbox_tray: **Battle API**: Players can use the API to conduct automated battles, which allows them to test different scenarios.
  
# How to use it
1. Copy the HTTPS link of the project.
2. Open Visual Studio and clone the repository to your computer.
3. To test the battle system, run the `GameAPI` project.
4. Use the battle controller to send a GET request with the battle configuration JSON.
5. After that you will get the result of the battle.

### JSON configuration of the battle:
```
{
  "Seed": 135333,
  "BattleType": "Test",
  "DayTime": "Evening",
  "Tempetura": "Cool",
  "Terrain": "Forest",
  "Weather": "Cloudy",
  "TeamConfigurations": [
    {
      "Player": {
        "Id": "d5a3fc04-453e-4a3c-9b89-9a5a56c2f404",
        "Username": "PlayerOne"
      },
      "UnitConfigurations": [
        {
          "Id": 1
        },
		{
          "Id": 2
        },
		{
          "Id": 3
        },
		{
          "Id": 4
        },
        {
          "Id": 5
        }
      ]
    },
    {
      "Player": {
        "Id": "b8e0a042-3c4f-4e18-a2d4-08d5f47a44f4",
        "Username": "PlayerTwo"
      },
      "UnitConfigurations": [
        {
          "Id": 6
        },
		{
          "Id": 7
        },
		{
          "Id": 8
        },
		{
          "Id": 9
        },
        {
          "Id": 10
        }
      ]
    }
  ]
}
```

# Contacts:
- **Email**: [mykhailo.honchar5@gmail.com](mailto:mykhailo.honchar5@gmail.com)
- **Telegram**: [WhyAlexFaktor](https://t.me/WhyAlexFaktor)

---
## License: 
### This project is licensed under the [Attribution-NonCommercial 4.0 International](https://creativecommons.org/licenses/by-nc/4.0/legalcode). See the LICENSE file for details.
