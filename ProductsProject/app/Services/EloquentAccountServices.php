<?php
/**
 * Created by PhpStorm.
 * User: Dell E6540
 * Date: 3/5/2019
 * Time: 3:54 PM
 */

namespace App\proba;


use App\Contracts\AccountServices;
use App\Http\Requests\AccountRequest;
use App\Models\Account;

class proba implements AccountServices
{
    function register(AccountRequest $request)
    {
        Account::create(
            [
                'companyName' => $request->companyName,
                'firstName' => $request->firstName,
                'lastName' => $request->lastName,
                'email' => $request->email,
                'password' => $request->password,
                'guid' => 'sdffsdsfdsdfs3232',
                'address' => $request->address,
                'token' => '4234343sd',

            ]
        );
    }

    function getAccountByUsernameAndPassword($email, $password)
    {

    }


}