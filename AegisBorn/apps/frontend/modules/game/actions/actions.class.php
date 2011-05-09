<?php

/**
 * index actions.
 *
 * @package    AegisBorn
 * @subpackage index
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class gameActions extends sfActions
{
 /**
  * Executes index action
  *
  * @param sfRequest $request A request object
  */
  public function executeIndex(sfWebRequest $request)
  {
      $guardUser = $this->getUser()->getGuardUser();
      $characters = $guardUser->getCharacters();
      $profile = $guardUser->getAegisBornProfile();
      if($profile == '' )
      {
          $profile = new AegisBornUserProfile();
          $profile->setCharacterSlots(1);
          $profile->setSfGuardUser($guardUser);
          $profile->save();
      }

  }
}
