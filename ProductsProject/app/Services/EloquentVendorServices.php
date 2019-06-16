<?php
/**
 * Created by PhpStorm.
 * User: Dell E6540
 * Date: 3/10/2019
 * Time: 8:53 PM
 */

namespace App\Services;


use App\Contracts\Collection;
use App\Contracts\UpdateUserGroupRequest;
use App\Contracts\UserGroupDTO;
use App\Contracts\UserGroupRequest;
use App\Contracts\VendorServices;
use App\DTO\VendorDTO;
use App\Http\Requests\UpdateVendorRequest;
use App\Http\Requests\VendorRequest;
use App\Models\Vendor;

class EloquentVendorService implements VendorServices
{

    protected $service;

    /**
     * EloquentVendorService constructor.
     * @param $service
     */
    public function __construct(VendorServices $service)
    {
        $this->service = $service;
    }

    function create(VendorRequest $request): void
    {
        Vendor::create([
           'name' => $request->name,
            'address' => $request->address,
            'contact' => $request->contact,
            'account_id' => $request->account_id
        ]);
    }

    function getVendorById($id): VendorDTO
    {
        // TODO: Implement getVendorById() method.
    }

    function update($id, UpdateVendorRequest $request): void
    {
        // TODO: Implement update() method.
    }

    function delete($id): void
    {
        // TODO: Implement delete() method.
    }

    function getAllGroups($idAccount): Collection
    {
        // TODO: Implement getAllGroups() method.
    }


}