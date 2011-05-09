/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package com.cjrgaming.aegisborn;

import com.cjrgaming.aegisborn.handlers.CharacterCreationHandler;
import com.cjrgaming.aegisborn.handlers.CharacterListHandler;
import com.cjrgaming.aegisborn.handlers.DBLoginHandler;
import com.cjrgaming.aegisborn.handlers.OnUserGoneHandler;
import com.cjrgaming.aegisborn.handlers.PublicKeyHandler;
import com.cjrgaming.aegisborn.simulation.World;
import com.smartfoxserver.v2.core.SFSEventType;
import com.smartfoxserver.v2.extensions.SFSExtension;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

/**
 *
 * @author Christian
 */
public class AegisBornExtension extends SFSExtension {

    private World world; // Reference to World simulation model

    public World getWorld() {
        return world;
    }
    EntityManagerFactory entityManagerFactory;

    @Override
    public void init() {
        world = new World(this);  // Creating the world model
        trace("Hello, this is my first SFS2X Extension!");
        addRequestHandler("publickey", PublicKeyHandler.class);
        addRequestHandler("login", DBLoginHandler.class);
        addRequestHandler("getCharacters", CharacterListHandler.class);
        addRequestHandler("createCharacter", CharacterCreationHandler.class);

        addEventHandler(SFSEventType.USER_DISCONNECT, OnUserGoneHandler.class);
        addEventHandler(SFSEventType.USER_LEAVE_ROOM, OnUserGoneHandler.class);
        addEventHandler(SFSEventType.USER_LOGOUT, OnUserGoneHandler.class);

        entityManagerFactory = Persistence.createEntityManagerFactory("AegisBornPU");
    }

    public EntityManagerFactory getEntityManagerFactory() {
        return entityManagerFactory;
    }
}
