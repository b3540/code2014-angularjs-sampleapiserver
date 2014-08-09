code2014-angularjs-sampleapiserver
==================================

Code 2014 in 定山渓温泉 きんぎょばち#1 AngularJS入門で使用した、
ブックマークリストを提供するサンプルの ASP.NET Web API サーバーです。

Azure Websites に Deploy してます。

http://code2014-angular-sampleapi.azurewebsites.net/

```GET /api/boobkmarks``` すると、JSON 形式ですべてのブックマークが返ります。

```
> curl http://code2014-angular-sampleapi.azurewebsites.net/api/bookmarks | jq ""
...
[
  {
    "Rating": 1,
    "URL": "https://facebook.com",
    "Title": "facebook",
    "Id": 1
  },
  {
    "Rating": 5,
    "URL": "https://twitter.com",
    "Title": "Twitter",
    "Id": 2
  }
]
```

その他の操作は以下。

- 指定のID=2 のブックマークを取得 ```GET /api/bookmarks/2```
- ブックマークを追加 (要求本文に追加するブックマークのJSON表現) ```POST /api/bookmarks```
- 指定のID=3 のブックマークを削除 ```DELETE /api/bookmarks/3```
- 指定のID=5 のブックマークを更新 (要求本文に更新内容のJSON表現) ```PUT /api/bookmarks/5```

AngularJS では、

    var api = $resource('http://code2014-angular-sampleapi.azurewebsites.net/api/bookmarks');

とするだけで上記 CRUD 操作を容易に記述することができるようになります。


