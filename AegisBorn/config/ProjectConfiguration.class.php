<?php

require_once dirname(__FILE__).'/../lib/vendor/symfony-1.4.8/lib/autoload/sfCoreAutoload.class.php';
sfCoreAutoload::register();

class ProjectConfiguration extends sfProjectConfiguration
{
  public function setup()
  {
    $this->enablePlugins('sfDoctrinePlugin',
                         'sfDoctrineGuardPlugin',
                         'sfForkedDoctrineApplyPlugin',
                         'sfFormExtraPlugin');
    $this->setWebDir($this->getRootDir().'/public_html/AegisBorn');
  }
}
