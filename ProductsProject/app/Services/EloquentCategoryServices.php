<?php
/**
 * Created by PhpStorm.
 * User: Dell E6540
 * Date: 3/7/2019
 * Time: 6:50 PM
 */

namespace App\Services;


use App\Contracts\CategoryServices;
use App\Contracts\CategoryUpdateRequest;
use App\HelperClass\CategoryHelper;
use App\Http\Requests\CategoryRequest;
use mysql_xdevapi\Collection;
use App\Models\Category;

class EloquentCategoryService implements CategoryServices
{
    function create(CategoryRequest $request)
    {
        // TODO: Implement create() method.
    }

    function getCategoryById($id): CategoryHelper
    {
            $category = Category::find($id)->first();
            dd($category);
            return new CategoryHelper($category->name, $category->account_id, $category->parent);
    }

    function delete($id): void
    {
        // TODO: Implement delete() method.
    }

    function update(CategoryUpdateRequest $request): void
    {
        // TODO: Implement update() method.
    }

    function getAllCategories($account_id): Collection
    {
        // TODO: Implement getAllCategories() method.
    }

}