<?php
/**
 * Created by PhpStorm.
 * User: Dell E6540
 * Date: 3/6/2019
 * Time: 8:39 PM
 */

namespace App\DTO;


class AccountHelper
{

    protected $id;
    protected $companyName;
    protected $firstname;
    protected $lastname;
    protected $email;
    protected $guid;
    protected $address;

    /**
     * AccountHelper constructor.
     * @param $id
     * @param $companyName
     * @param $firstname
     * @param $lastname
     * @param $email
     * @param $guid
     * @param $address
     */
    public function __construct($id, $companyName, $firstname, $lastname, $email, $guid, $address)
    {
        $this->id = $id;
        $this->companyName = $companyName;
        $this->firstname = $firstname;
        $this->lastname = $lastname;
        $this->email = $email;
        $this->guid = $guid;
        $this->address = $address;
    }

    /**
     * @return mixed
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * @param mixed $id
     */
    public function setId($id): void
    {
        $this->id = $id;
    }

    /**
     * @return mixed
     */
    public function getEmail()
    {
        return $this->email;
    }

    /**
     * @param mixed $email
     */
    public function setEmail($email): void
    {
        $this->email = $email;
    }

    /**
     * @return mixed
     */
    public function getAddress()
    {
        return $this->address;
    }

    /**
     * @param mixed $address
     */
    public function setAddress($address): void
    {
        $this->address = $address;
    }


    /**
     * @return mixed
     */
    public function getFirstname()
    {
        return $this->firstname;
    }

    /**
     * @param mixed $firstname
     */
    public function setFirstname($firstname): void
    {
        $this->firstname = $firstname;
    }

    /**
     * @return mixed
     */
    public function getLastname()
    {
        return $this->lastname;
    }

    /**
     * @param mixed $lastname
     */
    public function setLastname($lastname): void
    {
        $this->lastname = $lastname;
    }

    /**
     * @return mixed
     */
    public function getCompanyName()
    {
        return $this->companyName;
    }

    /**
     * @param mixed $companyName
     */
    public function setCompanyName($companyName): void
    {
        $this->companyName = $companyName;
    }

    /**
     * @return mixed
     */
    public function getGuid()
    {
        return $this->guid;
    }

    /**
     * @param mixed $guid
     */
    public function setGuid($guid): void
    {
        $this->guid = $guid;
    }


}