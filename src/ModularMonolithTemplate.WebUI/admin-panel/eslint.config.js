import eslintPluginReact from 'eslint-plugin-react';
import eslintPluginReactHooks from 'eslint-plugin-react-hooks';
import eslintPluginImport from 'eslint-plugin-import';
import eslintPluginJsxA11y from 'eslint-plugin-jsx-a11y';
import eslintPluginTypeScript from '@typescript-eslint/eslint-plugin';
import js from '@eslint/js';
import path from 'node:path';
import prettierConfig from 'eslint-config-prettier';
import parser from '@typescript-eslint/parser';
import eslintPluginPrettier from 'eslint-plugin-prettier';

export default [
  js.configs.recommended,
  eslintPluginReact.configs.recommended,
  {
    files: ['**/*.ts', '**/*.tsx'],
    ignores: [
      'node_modules',
      'dist',
      'src/vite-env.d.ts',
      'vite.config.ts'
    ],
    languageOptions: {
      parser,
      ecmaVersion: 2022,
      sourceType: 'module',
      globals: {
        document: true,
        window: true,
        console: true,
        localStorage: true,
        JSX: true,
      },
      parserOptions: {
        project: path.resolve('./tsconfig.app.json'),
        ecmaFeatures: {
          jsx: true,
        },
      },
    },
    plugins: {
      react: eslintPluginReact,
      'react-hooks': eslintPluginReactHooks,
      import: eslintPluginImport,
      'jsx-a11y': eslintPluginJsxA11y,
      '@typescript-eslint': eslintPluginTypeScript,
      prettier: eslintPluginPrettier
    },
    settings: {
      react: {
        version: 'detect',
      },
    },
    rules: {
      'react/react-in-jsx-scope': 'off',
      'prettier/prettier': 'warn'
    },
  },
  prettierConfig,
];
