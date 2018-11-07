## Xamarin 编译高德地图SDK

Xamarin使用高德地图SDK，就是将SDK中代码，生成一份C#的版本，供C#直接调用

### 创建库
1. [高德官网](https://lbs.amap.com/api/android-sdk/download)下载SDK

2. VS 新建一个供Android库
	将下载的 **jar文件** 添加到 *Jar* 目录下
	
	将下载的 **so文件** 添加到 *Assets* 目录下（如果没有新建一个Assets文件夹）
	
	添加完成后右击查看属性，jar文件的生成操作应该是*EmbeddedJar* so文件的生成操作应该是*EmbeddedNativeLibrary*
	
3. 开始编译 （command+B）
	
### 修改Java转C#时的部分错误
应该是由于Java和C#使用习惯不同，生成时会出现错误，大多数是**参数重名** **无法实现序列化** 

*Xamarin*提供了*Metadata.xml* 来解决这些问题


**参数重名** 

通过包名+方法+参数找到对应位置，并将名称替换掉

~~~
<attr path="/api/package[@name='com.amap.api.maps']/interface[@name='AMap.OnMapScreenShotListener']/method[@name='onMapScreenShot' and count(parameter)=2 and parameter[1][@type='android.graphics.Bitmap'] and parameter[2][@type='int']]" name="managedName">OnMapScreenShotListener2</attr>
~~~

**无法实现序列化** 

通过包名+方法 到对应位置，并将返回值替换掉

~~~
<attr path="/api/package[@name='com.amap.api.maps.model']/class[@name='AMapOptionsCreator']/method[@name='createFromParcel' and count(parameter)=1 and parameter[1][@type='android.os.Parcel']]"
    name="managedReturn">Java.Lang.Object</attr>
    
<attr path="/api/package[@name='com.amap.api.maps']/class[@name='AMapOptionsCreator']/method[@name='newArray' and count(parameter)=1 and parameter[1][@type='int']]"
    name="managedReturn">Java.Lang.Object[]</attr>
~~~

如果还存在其他情况，可以参考*Xamarin*官方说明[Xamarin Java Bindings Metadata](https://developer.xamarin.com/guides/android/advanced_topics/binding-a-java-library/customizing-bindings/java-bindings-metadata/)

	
