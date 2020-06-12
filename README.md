Dkvfx
-----

![Screenshot](https://i.imgur.com/FZy60GMl.jpg)

This is a Unity sample project that shows how to integrate a volumetric video
recorded with [Depthkit] to a [Visual Effect Graph].

[Depthkit]: https://www.depthkit.tv/
[Visual Effect Graph]: https://unity.com/visual-effect-graph

This project requires Unity 2019.3.

How To Install
--------------

This package uses the [scoped registry] feature to resolve package dependencies.
Please add the following sections to the manifest file (Packages/manifest.json).

[scoped registry]: https://docs.unity3d.com/Manual/upm-scoped.html

To the `scopedRegistries` section:

```
{
  "name": "Keijiro",
  "url": "https://registry.npmjs.com",
  "scopes": [ "jp.keijiro" ]
}
```

To the `dependencies` section:

```
"jp.keijiro.dkvfx": "0.1.2"
```

After changes, the manifest file should look like below:

```
{
  "scopedRegistries": [
    {
      "name": "Keijiro",
      "url": "https://registry.npmjs.com",
      "scopes": [ "jp.keijiro" ]
    }
  ],
  "dependencies": {
    "jp.keijiro.dkvfx": "0.1.2",
...
```
