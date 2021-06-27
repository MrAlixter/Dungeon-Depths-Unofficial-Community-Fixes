Dungeon_Depths
============== 
*If you've gotten this far, I assume that you know what this game is about.  Still, a quick disclaimer: Dungeon_Depths is intended for a mature audience.  If you are not over the age of 18, please do not play this game.*

This is the official developer documentation for Dungeon_Depths (D_D).  One of the neat things about putting our game up on a Git repository is that it makes it easy for  those outside our dev. team to add onto the game, and the purpose of this documentation is to make it as straightforward as possible to do so.  This documentation is not going to be set in stone, as with every new version there are a host of engine changes and tweaks, but I will try to keep these changes reflected in this guide as I make them.  This game runs on a homebrewed engine written in Visual Basic, and while we are working on streamlining common tasks as much as possible, occasionally things get a bit messy (hence this guide).

**(This guide is incomplete at this time)**

Basic Process of Contributing:
-------
*I assume that if you plan on modifying the game, you are at least familiar with simple Visual Basic and Git.  If not, [here](https://www.thecodingguys.net/tutorials/visualbasic/vb-tutorial) is a guide to simple VB, and [here](https://rogerdudler.github.io/git-guide/) is a guide to Git.  I did not write either, but they do a pretty good job of explaining things.*

 1. The first step to modifying D_D is to download a copy of the source code from the repository.  If you are planning on keeping your changes local to your machine, there is a link in the downloads page for it.  If you would like your changes to be considered for the main game, create a fork of the repo.  This should allow you to modify the current version of the game on your computer without affecting the main game.
 2. Once that is set up, make whatever changes you have planned.  I don't enforce a strict coding style, though please try to keep code as tidy as possible (ie Keep line length within reason for non text code, use consice, descriptive variable names, etc).  You don't need use comments to describe EVERYTHING you do, especially if its self-explanitory, but please use them to explain things if they get complex.
 3. Once finished with your modifications, push them to your fork and create a pull request.  In this pull request, please describe what you have done, and what name you would like to be credited as (Credit will be given for your work in the "special thanks" portion of the about page).  Once submitted, we will review your fork, and if everything seems to work and is stuff we'd like to see in the game, we will accept the pull request and merge it into the main branch.  Otherwise, the request will be rejected, and I will provide an explaination.