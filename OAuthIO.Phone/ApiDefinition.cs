using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace OAuthIOPhone
{
	// @interface OAuthIO : NSObject
	[BaseType (typeof(NSObject))]
	interface OAuthIO
	{
		NSURLConnection _connection;

		NSHTTPURLResponse _response;

		NSMutableURLRequest _req;

		NSMutableData _responseData;

		// +(NSString *)getPublicKey;
		[Static]
		[Export ("getPublicKey")]
		[Verify (MethodToProperty)]
		string PublicKey { get; }

		// -(id)initWithKey:(NSString *)key;
		[Export ("initWithKey:")]
		IntPtr Constructor (string key);

		// -(NSURLRequest *)getOAuthRequest:(NSString *)provider andUrl:(NSString *)url andOptions:(NSDictionary *)options;
		[Export ("getOAuthRequest:andUrl:andOptions:")]
		NSURLRequest GetOAuthRequest (string provider, string url, NSDictionary options);
	}

	// typedef void (^RequestSuccessBlock)(NSDictionary *NSString *NSHTTPURLResponse *);
	delegate void RequestSuccessBlock (NSDictionary arg0, string arg1, NSHTTPURLResponse arg2);

	// typedef void (^RequestErrorBlock)(NSError *);
	delegate void RequestErrorBlock (NSError arg0);

	// @interface OAuthIORequest : NSObject <NSURLConnectionDelegate, NSCopying>
	[BaseType (typeof(NSObject))]
	interface OAuthIORequest : INSURLConnectionDelegate, INSCopying
	{
		NSURLConnection _connection;

		NSHTTPURLResponse _response;

		NSMutableURLRequest _req;

		NSMutableData _responseData;

		NSMutableDictionary _headers;

		// @property (copy, nonatomic) RequestSuccessBlock success;
		[Export ("success", ArgumentSemantic.Copy)]
		RequestSuccessBlock Success { get; set; }

		// @property (copy, nonatomic) RequestErrorBlock error;
		[Export ("error", ArgumentSemantic.Copy)]
		RequestErrorBlock Error { get; set; }

		// @property (nonatomic, strong) OAuthIOData * data;
		[Export ("data", ArgumentSemantic.Strong)]
		OAuthIOData Data { get; set; }

		// @property (nonatomic, strong) NSString * contentType;
		[Export ("contentType", ArgumentSemantic.Strong)]
		string ContentType { get; set; }

		// +(NSString *)encodeURL:(NSString *)str;
		[Static]
		[Export ("encodeURL:")]
		string EncodeURL (string str);

		// +(NSString *)decodeURL:(NSString *)str;
		[Static]
		[Export ("decodeURL:")]
		string DecodeURL (string str);

		// -(id)initWithOAuthIOData:(OAuthIOData *)data;
		[Export ("initWithOAuthIOData:")]
		IntPtr Constructor (OAuthIOData data);

		// -(id)copyWithZone:(NSZone *)zone;
		[Export ("copyWithZone:")]
		unsafe NSObject CopyWithZone (NSZone* zone);

		// -(NSDictionary *)getCredentials;
		[Export ("getCredentials")]
		[Verify (MethodToProperty)]
		NSDictionary Credentials { get; }

		// -(void)addHeaderWithKey:(NSString *)key andValue:(NSString *)value;
		[Export ("addHeaderWithKey:andValue:")]
		void AddHeaderWithKey (string key, string value);

		// -(void)get:(NSString *)resource success:(RequestSuccessBlock)success;
		[Export ("get:success:")]
		void Get (string resource, RequestSuccessBlock success);

		// -(void)get:(NSString *)resource withParams:(id)params success:(RequestSuccessBlock)success;
		[Export ("get:withParams:success:")]
		void Get (string resource, NSObject @params, RequestSuccessBlock success);

		// -(void)post:(NSString *)resource withParams:(id)params success:(RequestSuccessBlock)success;
		[Export ("post:withParams:success:")]
		void Post (string resource, NSObject @params, RequestSuccessBlock success);

		// -(void)put:(NSString *)resource withParams:(id)params success:(RequestSuccessBlock)success;
		[Export ("put:withParams:success:")]
		void Put (string resource, NSObject @params, RequestSuccessBlock success);

		// -(void)patch:(NSString *)resource withParams:(id)params success:(RequestSuccessBlock)success;
		[Export ("patch:withParams:success:")]
		void Patch (string resource, NSObject @params, RequestSuccessBlock success);

		// -(void)del:(NSString *)resource success:(RequestSuccessBlock)success;
		[Export ("del:success:")]
		void Del (string resource, RequestSuccessBlock success);

		// -(void)delete:(NSString *)resource success:(RequestSuccessBlock)success;
		[Export ("delete:success:")]
		void Delete (string resource, RequestSuccessBlock success);

		// -(void)me:(NSArray *)filter success:(RequestSuccessBlock)success;
		[Export ("me:success:")]
		[Verify (StronglyTypedNSArray)]
		void Me (NSObject[] filter, RequestSuccessBlock success);
	}
}

