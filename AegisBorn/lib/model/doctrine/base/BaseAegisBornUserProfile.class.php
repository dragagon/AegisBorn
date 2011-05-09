<?php

/**
 * BaseAegisBornUserProfile
 * 
 * This class has been auto-generated by the Doctrine ORM Framework
 * 
 * @property integer $user_id
 * @property integer $character_slots
 * @property sfGuardUser $sfGuardUser
 * 
 * @method integer              getUserId()          Returns the current record's "user_id" value
 * @method integer              getCharacterSlots()  Returns the current record's "character_slots" value
 * @method sfGuardUser          getSfGuardUser()     Returns the current record's "sfGuardUser" value
 * @method AegisBornUserProfile setUserId()          Sets the current record's "user_id" value
 * @method AegisBornUserProfile setCharacterSlots()  Sets the current record's "character_slots" value
 * @method AegisBornUserProfile setSfGuardUser()     Sets the current record's "sfGuardUser" value
 * 
 * @package    AegisBorn
 * @subpackage model
 * @author     Your name here
 * @version    SVN: $Id: Builder.php 7490 2010-03-29 19:53:27Z jwage $
 */
abstract class BaseAegisBornUserProfile extends sfDoctrineRecord
{
    public function setTableDefinition()
    {
        $this->setTableName('aegis_born_user_profile');
        $this->hasColumn('user_id', 'integer', null, array(
             'type' => 'integer',
             'notnull' => true,
             ));
        $this->hasColumn('character_slots', 'integer', null, array(
             'type' => 'integer',
             'default' => 1,
             ));
    }

    public function setUp()
    {
        parent::setUp();
        $this->hasOne('sfGuardUser', array(
             'local' => 'user_id',
             'foreign' => 'id',
             'onDelete' => 'cascade'));

        $timestampable0 = new Doctrine_Template_Timestampable();
        $this->actAs($timestampable0);
    }
}