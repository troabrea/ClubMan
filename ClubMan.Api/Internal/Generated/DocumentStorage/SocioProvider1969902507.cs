// <auto-generated/>
#pragma warning disable
using ClubMan.Shared.Model;
using Marten.Internal;
using Marten.Internal.Storage;
using Marten.Schema;
using Marten.Schema.Arguments;
using Npgsql;
using System;
using System.Collections.Generic;
using Weasel.Core;
using Weasel.Postgresql;

namespace Marten.Generated.DocumentStorage
{
    // START: UpsertSocioOperation1969902507
    public class UpsertSocioOperation1969902507 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Socio, long>
    {
        private readonly ClubMan.Shared.Model.Socio _document;
        private readonly long _id;
        private readonly System.Collections.Generic.Dictionary<long, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public UpsertSocioOperation1969902507(ClubMan.Shared.Model.Socio document, long id, System.Collections.Generic.Dictionary<long, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_upsert_socio(?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Bigint;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bigint;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
            parameters[4].Value = _tenantId;
            parameters[4].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Upsert;
        }

    }

    // END: UpsertSocioOperation1969902507
    
    
    // START: InsertSocioOperation1969902507
    public class InsertSocioOperation1969902507 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Socio, long>
    {
        private readonly ClubMan.Shared.Model.Socio _document;
        private readonly long _id;
        private readonly System.Collections.Generic.Dictionary<long, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public InsertSocioOperation1969902507(ClubMan.Shared.Model.Socio document, long id, System.Collections.Generic.Dictionary<long, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_insert_socio(?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Bigint;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bigint;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
            parameters[4].Value = _tenantId;
            parameters[4].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Insert;
        }

    }

    // END: InsertSocioOperation1969902507
    
    
    // START: UpdateSocioOperation1969902507
    public class UpdateSocioOperation1969902507 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Socio, long>
    {
        private readonly ClubMan.Shared.Model.Socio _document;
        private readonly long _id;
        private readonly System.Collections.Generic.Dictionary<long, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public UpdateSocioOperation1969902507(ClubMan.Shared.Model.Socio document, long id, System.Collections.Generic.Dictionary<long, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_update_socio(?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Bigint;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bigint;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
            parameters[4].Value = _tenantId;
            parameters[4].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
            postprocessUpdate(reader, exceptions);
        }


        public override async System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            await postprocessUpdateAsync(reader, exceptions, token);
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Update;
        }

    }

    // END: UpdateSocioOperation1969902507
    
    
    // START: QueryOnlySocioSelector1969902507
    public class QueryOnlySocioSelector1969902507 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Socio>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlySocioSelector1969902507(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Socio Resolve(System.Data.Common.DbDataReader reader)
        {

            ClubMan.Shared.Model.Socio document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Socio>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Socio> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            ClubMan.Shared.Model.Socio document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Socio>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlySocioSelector1969902507
    
    
    // START: LightweightSocioSelector1969902507
    public class LightweightSocioSelector1969902507 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<ClubMan.Shared.Model.Socio, long>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Socio>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightSocioSelector1969902507(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Socio Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<long>(0);

            ClubMan.Shared.Model.Socio document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Socio>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Socio> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<long>(0, token);

            ClubMan.Shared.Model.Socio document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Socio>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightSocioSelector1969902507
    
    
    // START: IdentityMapSocioSelector1969902507
    public class IdentityMapSocioSelector1969902507 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<ClubMan.Shared.Model.Socio, long>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Socio>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapSocioSelector1969902507(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Socio Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<long>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Socio document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Socio>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Socio> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<long>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Socio document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Socio>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapSocioSelector1969902507
    
    
    // START: DirtyTrackingSocioSelector1969902507
    public class DirtyTrackingSocioSelector1969902507 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<ClubMan.Shared.Model.Socio, long>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Socio>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingSocioSelector1969902507(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Socio Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<long>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Socio document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Socio>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Socio> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<long>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Socio document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Socio>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingSocioSelector1969902507
    
    
    // START: QueryOnlySocioDocumentStorage1969902507
    public class QueryOnlySocioDocumentStorage1969902507 : Marten.Internal.Storage.QueryOnlyDocumentStorage<ClubMan.Shared.Model.Socio, long>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlySocioDocumentStorage1969902507(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override long AssignIdentity(ClubMan.Shared.Model.Socio document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id <= 0) _setter(document, database.Sequences.SequenceFor(typeof(ClubMan.Shared.Model.Socio)).NextLong());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateSocioOperation1969902507
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Socio, long>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertSocioOperation1969902507
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Socio, long>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertSocioOperation1969902507
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Socio, long>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override long Identity(ClubMan.Shared.Model.Socio document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlySocioSelector1969902507(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(long id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id).With(TenantIdArgument.ArgName, tenant);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Int64[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids).With(TenantIdArgument.ArgName, tenant);
        }

    }

    // END: QueryOnlySocioDocumentStorage1969902507
    
    
    // START: LightweightSocioDocumentStorage1969902507
    public class LightweightSocioDocumentStorage1969902507 : Marten.Internal.Storage.LightweightDocumentStorage<ClubMan.Shared.Model.Socio, long>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightSocioDocumentStorage1969902507(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override long AssignIdentity(ClubMan.Shared.Model.Socio document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id <= 0) _setter(document, database.Sequences.SequenceFor(typeof(ClubMan.Shared.Model.Socio)).NextLong());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateSocioOperation1969902507
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Socio, long>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertSocioOperation1969902507
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Socio, long>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertSocioOperation1969902507
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Socio, long>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override long Identity(ClubMan.Shared.Model.Socio document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightSocioSelector1969902507(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(long id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id).With(TenantIdArgument.ArgName, tenant);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Int64[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids).With(TenantIdArgument.ArgName, tenant);
        }

    }

    // END: LightweightSocioDocumentStorage1969902507
    
    
    // START: IdentityMapSocioDocumentStorage1969902507
    public class IdentityMapSocioDocumentStorage1969902507 : Marten.Internal.Storage.IdentityMapDocumentStorage<ClubMan.Shared.Model.Socio, long>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapSocioDocumentStorage1969902507(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override long AssignIdentity(ClubMan.Shared.Model.Socio document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id <= 0) _setter(document, database.Sequences.SequenceFor(typeof(ClubMan.Shared.Model.Socio)).NextLong());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateSocioOperation1969902507
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Socio, long>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertSocioOperation1969902507
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Socio, long>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertSocioOperation1969902507
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Socio, long>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override long Identity(ClubMan.Shared.Model.Socio document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapSocioSelector1969902507(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(long id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id).With(TenantIdArgument.ArgName, tenant);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Int64[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids).With(TenantIdArgument.ArgName, tenant);
        }

    }

    // END: IdentityMapSocioDocumentStorage1969902507
    
    
    // START: DirtyTrackingSocioDocumentStorage1969902507
    public class DirtyTrackingSocioDocumentStorage1969902507 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<ClubMan.Shared.Model.Socio, long>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingSocioDocumentStorage1969902507(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override long AssignIdentity(ClubMan.Shared.Model.Socio document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id <= 0) _setter(document, database.Sequences.SequenceFor(typeof(ClubMan.Shared.Model.Socio)).NextLong());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateSocioOperation1969902507
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Socio, long>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertSocioOperation1969902507
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Socio, long>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertSocioOperation1969902507
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Socio, long>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Socio document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override long Identity(ClubMan.Shared.Model.Socio document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingSocioSelector1969902507(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(long id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id).With(TenantIdArgument.ArgName, tenant);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Int64[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids).With(TenantIdArgument.ArgName, tenant);
        }

    }

    // END: DirtyTrackingSocioDocumentStorage1969902507
    
    
    // START: SocioBulkLoader1969902507
    public class SocioBulkLoader1969902507 : Marten.Internal.CodeGeneration.BulkLoader<ClubMan.Shared.Model.Socio, long>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.Socio, long> _storage;

        public SocioBulkLoader1969902507(Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.Socio, long> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY public.mt_doc_socio(\"mt_dotnet_type\", \"id\", \"mt_version\", \"tenant_id\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_socio_temp(\"mt_dotnet_type\", \"id\", \"mt_version\", \"tenant_id\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into public.mt_doc_socio (\"id\", \"tenant_id\", \"data\", \"mt_version\", \"mt_dotnet_type\", mt_last_modified) (select mt_doc_socio_temp.\"id\", mt_doc_socio_temp.\"tenant_id\", mt_doc_socio_temp.\"data\", mt_doc_socio_temp.\"mt_version\", mt_doc_socio_temp.\"mt_dotnet_type\", transaction_timestamp() from mt_doc_socio_temp left join public.mt_doc_socio on mt_doc_socio_temp.id = public.mt_doc_socio.id where public.mt_doc_socio.id is null)";

        public const string OVERWRITE_SQL = "update public.mt_doc_socio target SET tenant_id = source.tenant_id, data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, mt_last_modified = transaction_timestamp() FROM mt_doc_socio_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_socio_temp as select * from public.mt_doc_socio limit 0";


        public override void LoadRow(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.Socio document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer)
        {
            writer.Write(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(document.Id, NpgsqlTypes.NpgsqlDbType.Bigint);
            writer.Write(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(tenant.TenantId, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb);
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.Socio document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
        {
            await writer.WriteAsync(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar, cancellation);
            await writer.WriteAsync(document.Id, NpgsqlTypes.NpgsqlDbType.Bigint, cancellation);
            await writer.WriteAsync(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(tenant.TenantId, NpgsqlTypes.NpgsqlDbType.Varchar, cancellation);
            await writer.WriteAsync(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb, cancellation);
        }


        public override string MainLoaderSql()
        {
            return MAIN_LOADER_SQL;
        }


        public override string TempLoaderSql()
        {
            return TEMP_LOADER_SQL;
        }


        public override string CreateTempTableForCopying()
        {
            return CREATE_TEMP_TABLE_FOR_COPYING_SQL;
        }


        public override string CopyNewDocumentsFromTempTable()
        {
            return COPY_NEW_DOCUMENTS_SQL;
        }


        public override string OverwriteDuplicatesFromTempTable()
        {
            return OVERWRITE_SQL;
        }

    }

    // END: SocioBulkLoader1969902507
    
    
    // START: SocioProvider1969902507
    public class SocioProvider1969902507 : Marten.Internal.Storage.DocumentProvider<ClubMan.Shared.Model.Socio>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public SocioProvider1969902507(Marten.Schema.DocumentMapping mapping) : base(new SocioBulkLoader1969902507(new QueryOnlySocioDocumentStorage1969902507(mapping)), new QueryOnlySocioDocumentStorage1969902507(mapping), new LightweightSocioDocumentStorage1969902507(mapping), new IdentityMapSocioDocumentStorage1969902507(mapping), new DirtyTrackingSocioDocumentStorage1969902507(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: SocioProvider1969902507
    
    
}

