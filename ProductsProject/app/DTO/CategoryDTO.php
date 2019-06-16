<?php
/**
 * Created by PhpStorm.
 * User: Dell E6540
 * Date: 3/7/2019
 * Time: 6:42 PM
 */

namespace App\DTO;


class CategoryHelper
{
    protected $name;
    protected $account_id;
    protected $parent;

    /**
     * CategoryHelper constructor.
     * @param $name
     * @param $account_id
     * @param $parent
     */
    public function __construct($name, $account_id, $parent = null)
    {
        $this->name = $name;
        $this->account_id = $account_id;
        $this->parent = $parent;
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

    /**
     * @return mixed
     */
    public function getAccountId()
    {
        return $this->account_id;
    }

    /**
     * @param mixed $account_id
     */
    public function setAccountId($account_id): void
    {
        $this->account_id = $account_id;
    }

    /**
     * @return null
     */
    public function getParent()
    {
        return $this->parent;
    }

    /**
     * @param null $parent
     */
    public function setParent($parent): void
    {
        $this->parent = $parent;
    }


}