<?php

/**
 * AegisBornCharacter form base class.
 *
 * @method AegisBornCharacter getObject() Returns the current form's model object
 *
 * @package    AegisBorn
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseAegisBornCharacterForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'id'         => new sfWidgetFormInputHidden(),
      'user_id'    => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('sfGuardUser'), 'add_empty' => false)),
      'name'       => new sfWidgetFormInputText(),
      'sex'        => new sfWidgetFormInputText(),
      'class'      => new sfWidgetFormInputText(),
      'level'      => new sfWidgetFormInputText(),
      'position_x' => new sfWidgetFormInputText(),
      'position_y' => new sfWidgetFormInputText(),
      'created_at' => new sfWidgetFormDateTime(),
      'updated_at' => new sfWidgetFormDateTime(),
    ));

    $this->setValidators(array(
      'id'         => new sfValidatorChoice(array('choices' => array($this->getObject()->get('id')), 'empty_value' => $this->getObject()->get('id'), 'required' => false)),
      'user_id'    => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('sfGuardUser'))),
      'name'       => new sfValidatorString(array('max_length' => 255, 'required' => false)),
      'sex'        => new sfValidatorString(array('max_length' => 1, 'required' => false)),
      'class'      => new sfValidatorString(array('max_length' => 50, 'required' => false)),
      'level'      => new sfValidatorInteger(array('required' => false)),
      'position_x' => new sfValidatorInteger(array('required' => false)),
      'position_y' => new sfValidatorInteger(array('required' => false)),
      'created_at' => new sfValidatorDateTime(),
      'updated_at' => new sfValidatorDateTime(),
    ));

    $this->validatorSchema->setPostValidator(
      new sfValidatorDoctrineUnique(array('model' => 'AegisBornCharacter', 'column' => array('name')))
    );

    $this->widgetSchema->setNameFormat('aegis_born_character[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'AegisBornCharacter';
  }

}
