<?php
/**
 * Created by PhpStorm.
 * User: Dell E6540
 * Date: 3/7/2019
 * Time: 8:38 PM
 */

namespace App\DTO;


class UserGroupHelper
{
        protected $name;

    /**
     * UserGroupHelper constructor.
     * @param $name
     */
    public function __construct($name)
    {
        $this->name = $name;
    }

    /**
     * @return mixed
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * @param mixed $name
     */
    public function setName($name): void
    {
        $this->name = $name;
    }


}